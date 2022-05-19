# 云加密是什么

云加密能力，我们可以理解为软件的激活授权，没有任何学习成本，YGXJ_Core已经完成了全部验证、授权工作，你只需在你的应用中直接使用。

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