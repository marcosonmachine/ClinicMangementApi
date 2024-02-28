#!/bin/bash

# Generate a random string for migration name
migration_name=$(cat /dev/urandom | tr -dc 'a-zA-Z0-9' | fold -w 10 | head -n 1)

# Create a migration with the random string name
dotnet ef migrations add $migration_name

# Update the database
dotnet ef database update

