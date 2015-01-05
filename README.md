# Respoke C# / .NET library

An early library for building .NET server apps using Respoke. Please send a PR or request features you need.

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
