# Update Group Information

Updates group information. Administrator permissions are required to perform this action.

## Request

See Common parameters and headers that are used by all requests related to the Leaderboard Building Block.

Method  | Request URI
------- | -----------
PUT     | `/api/groups`

### Request parameters

No parameters

### JSON Body

```json
{
  "name": "string",
  "description": "string",
  "members": [
    "string"
  ]
}
```

Element name        | Required  | Type       | Description
--------------------|-----------|------------|------------
name|Yes|String|Name of the group
description|No|String|Group description
members|No|String Array|List of user gamertags to add to this group on creation

## Response

| Status Code | Description |
|-------------|-------------|
|204|Group updated|


### JSON Body

Empty body