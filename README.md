# Respoke C# / .NET library

This is an early library for building .NET server apps using Respoke.

Respoke platform documentation can be viewed at https://docs.respoke.io.

Please GitHub to [report bugs or request features](https://github.com/respoke/dotnet-respoke-admin/issues), or start a discussion on the [Respoke community website](http://community.respoke.io).

## Usage

### Getting an auth token for a client

```csharp
using Respoke;

// . . .

RespokeClient respoke = new RespokeClient();
RespokeEndpointTokenRequestBody reqParams = new RespokeEndpointTokenRequestBody () {
    appId = "get-from-respoke-dev-console",
    appSecret = "get-from-respoke-dev-console",
    endpointId = "your-clients-username",
    roleId = "get-from-respoke-dev-console"
};
RespokeResponse resp = respoke.GetEndpointTokenId(reqParams);

Console.WriteLine(resp.body.tokenId);

// Return `resp.body.tokenId` to your client
```

# License

Copyright 2014, Digium, Inc. All rights reserved.

This source code is licensed under The MIT License found in the LICENSE file in the root directory of this source tree.

For all details and documentation: https://www.respoke.io
