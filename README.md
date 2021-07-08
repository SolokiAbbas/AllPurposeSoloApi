# AllPurpose Api 
This is an Api that can send requests to 3rd party Apis. It uses docker to containerize and JWT for Auth.

# Api

### Summary
An api to some example sites and a graphql Client.

Made with .Net 5.0



### GraphQl
Body Query should be sent with a Post to the api. The query should be in the body. 
When you make a request you'll need to include 2 payload objects, query, and variables.
query: contains your query or mutation strings.
variables: contains the variable values used within your query.

### Example GraphQl
query{
  Character(id: $id){
    name {
      first
      middle
      last
      full
      native
      userPreferred
    }
    gender
    age
    siteUrl
  }
}

variables: {id = 246}

