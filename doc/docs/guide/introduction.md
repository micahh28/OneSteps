# 介绍

:::tip
官方指南假设你已了解关于 C#、.Net 和 Visual Studio 的基础知识。如果你不熟悉.Net或C#，阅读此文档可能不是一个好的主意
:::

## OneSteps 是什么

OneSteps 是一套基于.Net framework4.7的动态库，它提供了一些常用工具集合，例如获取计算机硬盘序列号、操作注册表等。

## 起步

<p>
  <ActionLink class="primary" url="installation.html">
    安装
  </ActionLink>
</p>

在 Visual Studio 中添加对类型库的引用

1. 新建一个控制台应用程序。

2. 选择“项目”、“添加引用” 。

3. 在引用管理器中，选择“COM”。

4. 从列表中选择类型库，或通过浏览选择 OneSteps.Utils.dll 文件。

5. 选择 “确定” 。

:::tip
根据你使用的 Visual Studio 版本，菜单和对话框选项可能会有所不同
:::

## 示例

在Main方法中：

```java
using System;
using OneSteps.Utils.WinOS;

class Hello
{
    static void Main()
    {
         Console.WriteLine(WinOSInfo.MachineName());
         Console.ReadKey();
    }
}
 
```

我们已经成功创建了一个控制台应用！并且打印出了当前计算机名

## 准备好了吗？

我们刚才简单介绍了 OneSteps 最基本的引入——本教程的其余部分将更加详细地涵盖其他主要功能！
