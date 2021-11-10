Feature: Add User Api
  In order to verify Add User service
  As an user
  I want to test different combinatoins of Service

  @api @positive @automated
  Scenario: Execute API call to add new user
    When User hits service 'AddUserApi'
    Then User can see status code is 201
    And User validates that the response contains user name 'TestUser'