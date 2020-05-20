<p align="middle">
    <img src="https://www.rifos.org/assets/img/logo.svg" alt="logo" height="100" >
</p>
<h3 align="middle"><code>rns-net-lib</code></h3>
<p align="middle">
    RNS .NET SDK
</p>
<p align="middle">
    <a href="https://developers.rsk.co/rif/rns/libs/">
      <img src="https://img.shields.io/badge/-docs-brightgreen" alt="docs" />
    </a>
</p>

Implementation for resolvers for the RIF Name Service, available for .NET framework.

```csharp
var resolver = new RnsResolver();
var address = resolver.GetAddress("ale.rsk").Result;
```
