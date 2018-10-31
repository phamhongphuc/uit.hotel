SCHEMA_PATH="http://localhost:3000/api/graphql"

get-graphql-schema $SCHEMA_PATH > "graphql/schema.json" --json
get-graphql-schema $SCHEMA_PATH > "graphql/schema.gql"
