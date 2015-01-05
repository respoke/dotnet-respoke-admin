# Respoke C# / .NET library

An early library for building .NET server apps using Respoke. Please send a PR or request features you need.

## Usage

### Getting an auth token for a client

```csharp
using Respoke;

// . . .

RespokeClient respoke = new RespokeClient();
RespokeEndpointTokenRequestBody reqParams = new RespokeEndpointTokenRequestBody () {
    appId = "391095be-6e83-40e3-90a5-439809ad2396",
    appSecret = "7e34caf2-1814-4e11-a8fd-7796b8c787a1",
    endpointId = "myendpoint123",
    roleId = "35D43FE7-CDE8-4DE0-BA5F-BC6A29DCF13A"
};
RespokeResponse resp = respoke.GetEndpointTokenId(reqParams);

Console.WriteLine(resp.body.tokenId);

// Return `resp.body.tokenId` to your client
```

# License

Copyright 2014, Digium, Inc. All rights reserved.

This source code is licensed under The MIT License found in the LICENSE file in the root directory of this source tree.

For all details and documentation: https://www.respoke.io
