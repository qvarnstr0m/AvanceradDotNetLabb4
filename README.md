# AvanceradDotNetLabb4

# PersonData API

## Endpoints

### ListAllPersons

- Method: GET
- URL: /PersonData/ListAllPersons

Returns a list of all persons in the system.

Example request:
GET /PersonData/ListAllPersons


### ListInterestsByPerson

- Method: GET
- URL: /PersonData/ListInterestsByPerson?personId={personId}

Returns a list of interests for the person with the specified personId.

Example request:
GET /PersonData/ListInterestsByPerson?personId=1


### ListLinksByPerson

- Method: GET
- URL: /PersonData/ListLinksByPerson?personId={personId}

Returns a list of links for the person with the specified personId.

Example request:

GET /PersonData/ListLinksByPerson?personId=1


### AddNewInterestPerson

- Method: POST
- URL: /PersonData/AddNewInterestPerson
- Request body: JSON object with `interestId` and `personId`

Adds a new interest to a person.

Example request:

POST /PersonData/AddNewInterestPerson
Content-Type: application/json

{
"interestId": 1,
"personId": 2
}


### AddNewLink

- Method: POST
- URL: /PersonData/AddNewLink
- Request body: JSON object with `url` and `fkInterestPersonId`

Adds a new link with the specified URL and associates it with an interest-person relationship.

Example request:

POST /PersonData/AddNewLink
Content-Type: application/json

{
"url": "https://www.example.com",
"fkInterestPersonId": 1
}


## Models

### AddNewInterestPersonRequest

- Properties:
  - InterestId (int): The ID of the interest to add to the person.
  - PersonId (int): The ID of the person to add the interest to.

### AddNewLinkRequest

- Properties:
  - Url (string): The URL of the new link.
  - FkInterestPersonId (int): The ID of the interest-person relationship to associate with the new link.
