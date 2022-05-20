# 可视化配置功能

可视化配置功能是指为你的应用程序提供一套可视化参数配置页面，这是非常简单，你无需编写配置页面，只需要安装规则定义参数类型。介绍之前我们先看一下通常是如果做参数配置的。

:::tip
如果阅读文档有困难，你也并不想关注OneSteps内部机制，亦或你时间很紧，页面最下方给了一个完整的示例，你可以拷贝到你的项目中，做些对应修改，就可以基本玩转可视化配置工具了。
:::

## 传统做法

我们一般把参数配置在 `app.config` 或 `web.config` 中，以键值对形式设置参数。像这样：

```xml
<appSettings>
		<!--数据库：1==网络版，2==单机版-->
		<add key="dbbase" value="2" />
        <!--系统版本名称-->
		<add key="SysVersionName" value="阳光心健" />
        <!--系统名称-->
		<add key="SysName" value="" />
</appSettings>
```

在需要使用的地方，我们使用 `ConfigurationManager` 方法，获取到对应key的值

```java
// 读取dbbase参数值
int sysVersionName = Convert.ToInt(ConfigurationManager.AppSettings["dbbase"]);
```

这样简单的做法带来的问题是，仅仅靠xml上的注释来提示参数选项是远远不够的，极容易出错，也带来更多的沟通成本、维护成本。同时，也是不安全的，例如上述代码中，如果 `dbbase` 配置成为 `a` ，就会引发程序运行出错。

## 使用OneSteps

使用Visual Studio 创建一个控制台程序，引入YGXJ_Core.dll。

```java
using System;
using OneSteps.core;

class Hello
{
    static void Main()
    {
       // 定义应用配置框架
       SettingSchema schema = new SettingSchema()
       {
           // 应用名称
           AppName = "团体减压程序",
           // 应用描述
           Description = "团体减压配置管理中心",
           Options = new List<SettingOption>()
           {
              // 定义一个配置选项
               new InputOptions()
               {
                   // 选项的key
                   Lable = "appName",
                   // 选项的值
                   Value = "阳光心健团体减压程序"
               }
           }
        };

         // 初始化参数
         YGSettings.Instance.Init(schema);

         // 以上，已经完成了一个参数key为appName的参数定义。在需要使用的位置通过一下方法获取appName的值

         Console.WriteLine(YGSettings.Instance.Get("appName"));
         Console.ReadKey();

        // 运行程序，控制台会打印出 阳光心健团体减压程序
    }
}
 
```

至此，你已经获得了可视化配置能里，打开 `阳光心健运维平台` 进入配置管理页面，扫描你的程序所在目录，即可在界面中修改参数 `appName` 的值。

:::tip
YGSettings使用了单例模式，且线程安全，你可以放心的使用`YGSettings.Instance.Init()` 也可在你项目任意位置使用 `YGSettings.Instance.Get()`方法。
:::


# API

## Init(SettingSchema schema)

YGSettings.Instance.Init(schema)方法

是初始化参数方法，它会在你的应用程序中生成配置文件。同时它不会覆盖已经生成的配置文件。配置文件生成后，它的修改和维护工作就交由`可视化运维工具`托管，你无需关注。

- **参数** `SettingSchema`

定义的全部配置选项

- **返回** 

无

## Get(string lable)

YGSettings.Instance.Get(lable)方法

是根据 `SettingSchema` 中定义的 `Lable` 值获取参数值，返回 `dynamic` 类型的value。你也可以在Get后加上类型定义，定义返回值类型，例如：

```java
bool isShowLogo = YGSettings.Instance.Get<bool>("isShowLogo")
```

- **参数** `sting`

Lable是sting类型的值

- **返回** 

参数值,是动态类型，在运行时解析其操作对象

## Reset()
YGSettings.Instance.Reset()方法

重置全部参数，恢复默认值。也就是你应用程序参数配置恢复到在Init方法中定义的默认值。

- **参数** 

无

- **返回** 

无

# SettingSchema 配置框架

这是YGXJ_Core定义的一个类，用于定义应用整体参数框架。有如下属性：

- **AppName**：`sting` 应用名称
- **Description**：`sting` 应用描述
- **SettingOption**：配置选项类

## SettingOption 配置选项

这是对应到每一个配置选项，例如，软件是否显示logo，它就是一个SettingOption。

```java

Options = new List<SettingOption>()
{
   // 定义一个配置选项
    new InputOptions()
    {
        // 选项的key
        Lable = "isShowLogo",
        // 选项的值
        Value = "true"
    }
}
 
```
上面就定义了一个isShowLogo参数，如果需要使用，只需 `YGSettings.Instance.Get("isShowLogo")`

但是上面这样简单的处理这样还有一些问题，因为这样定义的参数，是一个文本输入框，需要在配置界面手动输入`true`或者`false`，操作不友好，还可能出错。你可能已经注意到，我们在上面的示例中，我们使用了`InputOptions`，YGXJ_Core还提供了其他配置类型。例如

```java

Options = new List<SettingOption>()
{
   // 定义一个配置选项
    new SwitchOptions()
    {
         GroupName = "系统设置",
         Lable = "showLogo",
         LableText = "是否显示logo",
         Description = "是否在应用程序中显示logo",
         ActiveText = "是",
         InactiveText = "否",
         Value = false,
    }
}
 
```
使用 `SwitchOptions` 定义一个配置项，它可以在界面中生成一个好看的开关按钮，当然这些添加参数需要你来设计，你的应用程序最终只需要关注`lable`和`value`。额外的参数是为了让可视化配置界面更加好看。

除此之外，还有`InputNumberOptions`、`SelectOptions`、`RadioOptions`


# 一个完整的示例

```java

using System;
using YGXJ_Core.Utility.WinOS;

class Hello
{
    static void Main()
    {
       // 定义应用配置框架
       SettingSchema schema = new SettingSchema()
       {
           AppName = "可视化配置项目测试Demo",
           Description = "这是一个简单的用于测试可视化配置工具的demo，在此验全新参数配置方式",
           Options = new List<SettingOption>()
           {
               // 文本类配置项
               new InputOptions()
               {
                  // 组名
                  GroupName = "系统设置",
                  // 输入框水印文字
                  Placeholder = "请输入软件名称",
                  Lable = "appName",
                  LableText = "软件名称",
                  Description = "软件的名称支持自定义，在此输入",
                  Value = "测试Demo"
               },
               // 数字类配置项
               new InputNumberOptions()
               {
                  GroupName = "系统设置",
                  Lable = "loginErrCount",
                  LableText = "登陆失败阀值",
                  Description = "设置登陆失败次数后锁定系统",
                  Min = 1,
                  Max = 10,
                  Value = 1,
               },
               // 开关类配置项
               new SwitchOptions()
               {
                  GroupName = "系统设置",
                  Lable = "isShowLogo",
                  LableText = "是否显示logo",
                  Description = "是否在应用程序中显示logo",
                  // 选中文字
                  ActiveText = "是",
                  // 选中文字
                  InactiveText = "否",
                  Value = true,
               },
               // 列表选择类配置项
               new SelectOptions()
               {
                  GroupName = "系统设置",
                  // 选择框水印文字
                  Placeholder = "请选择数据库类型",
                  Lable = "DBType",
                  LableText = "数据库类型",
                  Description = "配置软件所使用的数据库",
                  Value = "3",
                  // 预设数据字典 value, label
                  Data = new Dictionary<string, string>(){ {"1","Oracle"},{ "2", "MySql"},{"3","SqlServer"} },
               },
               // 单选类配置项
               new RadioOptions()
               {
                  GroupName = "其他设置",
                  Lable = "skin",
                  LableText = "软件主题",
                  Description = "配置软件界面风格",
                  Value = "",
                  // 预设数据字典 value, label
                  Data = new Dictionary<string, string>(){ {"1","心健"},{ "2", "楚一"},{"3","惠民"},{"4","新晨"} },
               },
               // 多选类配置项
               new CheckboxOptions()
               {
                  GroupName = "其他设置",
                  Lable = "deviceType",
                  LableText = "硬件设备类型",
                  Description = "连接的硬件设备类型",
                  Value = "",
                  // 预设数据字典 value, label
                  Data = new Dictionary<string, string>(){ {"1","脑波"},{ "2", "心率"},{"3","呼吸"} },
               },
           }
        };

         // 初始化参数
         YGSettings.Instance.Init(schema);
    }
}
 
```

# 软件授权功能

没有任何学习成本，OneSteps已经完成了全部验证、授权工作，你只需在你的应用中直接使用。

## 验证软件授权状态

```java
 // 验证软件授权状态
 var res = ActivationVerify.VerifySoftware();
 if (res.IsAuthorized)
 {
     // 验证通过 todo something
 }
 else
 {
     // 验证授权不通过
     // res.Message可以获取不通过的原因
 }
```

## 验证方法 VerifySoftware

ActivationVerify.VerifySoftware()方法

是获取当前应用程序所在目录下的【许可证文件】信息。根据许可证文件中所提供的信息，判断当前应用程序是否是授权应用

- **参数**

无

- **返回** `VerifyResult`类型
```js
  IsAuthorized  是否授权许可
  Code  状态码
  Message  消息，结果原因
  Expiration  过期时间
```