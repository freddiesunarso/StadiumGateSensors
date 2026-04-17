# Stadium Gate Sensors API
This repo contains the API implementation for Stadium Gate Sensors with 2 endpoints

## HTTP POST /gates
Publish an asynchronous event (which came from a stadium gate) which then gets picked up by the event handler to populate SQLite DB table "GateAccesses".

## HTTP GET /gates
Query the SQLite DB table "GateAccesses" by the search query param values.
