Feature: Weather Api
  In order to verify weather service
  As an user
  I want to test different combinatoins of Service

  @api @positive @automated
  Scenario: Execute API call to get city data
    When User hits service 'WeatherApi'
    Then User can see status code is 200
    And User validates that the response contains city name 'Islamabad'