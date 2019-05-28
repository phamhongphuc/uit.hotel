import gql from 'graphql-tag';

export const initializeAdminAccount = gql`
    mutation initializeAdminAccount($email: String!, $password: String!) {
        initializeAdminAccount(email: $email, password: $password)
    }
`;
