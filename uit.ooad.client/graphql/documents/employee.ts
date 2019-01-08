import gql from 'graphql-tag';

export const getEmployees = gql`
    query getEmployees {
        employees {
            id
            name
            identityCard
            phoneNumber
            address
            email
            birthdate
            gender
            startingDate
            isActive
            position {
                id
                name
            }
        }
    }
`;

export const createEmployee = gql`
    mutation createEmployee($input: EmployeeCreateInput!) {
        createEmployee(input: $input) {
            id
        }
    }
`;

export const updateEmployee = gql`
    mutation updateEmployee($input: EmployeeUpdateInput!) {
        updateEmployee(input: $input) {
            id
        }
    }
`;

export const resetPassword = gql`
    mutation resetPassword($id: ID!) {
        resetPassword(id: $id)
    }
`;

export const setIsActiveAccount = gql`
    mutation setIsActiveAccount($id: ID!, $isActive: Boolean!) {
        setIsActiveAccount(id: $id, isActive: $isActive)
    }
`;

export const changePassword = gql`
    mutation changePassword($password: String!, $newPassword: String!) {
        changePassword(password: $password, newPassword: $newPassword)
    }
`;
