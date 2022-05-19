# 介绍

:::tip
官方指南假设你已了解关于 C#、.Net 和 Visual Studio 的基础知识。如果你不熟悉.Net或C#，阅读此文档可能不是一个好的主意
:::

## YGXJ_Core 是什么

YGXJ_Core (YGXJ_Core.dll) 是一套基于.Net framework4.5的动态库，它提供了[运维工具]、[云加密]等系统的接口，帮助我们快速接入并获得上述系统功能。同时还提供了一些常用工具集合，例如获取计算机硬盘序列号、操作注册表等。

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

4. 从列表中选择类型库，或通过浏览选择 YGXJ_Core.dll 文件。

5. 选择 “确定” 。

:::tip
根据你使用的 Visual Studio 版本，菜单和对话框选项可能会有所不同
:::

## 示例

在Main方法中：

```java
using System;
using YGXJ_Core.Utility.WinOS;

class Hello
{
    static void Main()
    {
         Console.WriteLine(WinUtil.GetHDid());
         Console.ReadKey();
    }
}
 
```

我们已经成功创建了一个控制台应用！并且打印出了当前计算机的磁盘序列号

:::tip
请勿将YGXJ_Core.dll放在你项目的编译目录中，例如放在Debug目录中，这样做是错误的，尽管它不会影响你的项目运行。
正确的做法应该是放在你的代码文件夹中，它也是你代码的一部分。
:::

## 准备好了吗？

我们刚才简单介绍了 YGXJ_Core 最基本的引入——本教程的其余部分将更加详细地涵盖其他主要功能！
