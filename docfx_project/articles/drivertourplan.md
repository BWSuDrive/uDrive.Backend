# Driver Tour Plan
Im Vorfeld muss die Person als Fahrer registriert sein, siehe hier [Registrieren als Fahrer](register.md)
## Schritt 1 : Einen TourPlan erstellen
### `POST /TourPlans`
### Model
An die Url wird folgendes Model gesendet, wichtig ist, dass das Feld `idDriver` zwar mitgesendet werden muss, aber nicht die aktuelle Id sein muss, das System erkennt selbständig wechler Fahrer den Request stellt
```json
 {
  "idDriver": "id_not_needed",
  "departure": "2023-09-26T17:52:12.257Z",
  "stopRequests": 0,
  "eta": "00:15:00",
  "start": "string",
  "destination": "string",
  "message": "string",
  "currentLatitude": 50.08513701910111,
  "currentLongitude": 8.452825469725695
 }
```
### Response
```json
{
    "id": "id",
    "idDriver": "idDriver",
    "departure": "2023-09-26T17:52:12.257Z",
    "stopRequests": 0,
    "eta": "00:15:00",
    "start": "string",
    "destination": "string",
    "message": "string",
    "currentLatitude": 50.08513701910111,
    "currentLongitude": 8.452825469725695,
    "driver": {
       ...
        },
        "tourPlans": [
            null
        ]
    },
    "passengers": [],
    "passengerRequests": []
}
```

## Schritt 2 : Passenger Requests
### Schritt 2.1 : Anfragen erhalten
Während der Laufzeit, kann der Fahrer jederzeit erfragen, ob sich Personen für seine Tour gemeldet haben und eine Mitfahrgelegenheit suchen
#### `GET /PassengerRequests/GetPassengerRequests`
Es müssen keine weiteren Parameter mitgeliefert werden, der Fahrer erhält dann folgenden Response, wenn es interessenten gibt
```json
[
    {
        "id": "id",
        "idPerson": "idPerson",
        "idTourPlan": "idTourPlan",
        "message": "Stehe an der Ecke",
        "currentLatitude": 0,
        "currentLongitude": 0,
        "isPending": true,
        "isDenied": false,
        "person": {
            "firstname": "Passenger1_Firstname",
            "lastname": "Lastname_Passenger1",
            "email": "Passenger1@udrive.de",
            "phoneNumber": "number",

            ...
        },
        "tourPlan": null
    }
]
 ```
 Sollte das nicht der Fall sein, erhält er `Status404NotFound` zurück
### Schritt 2.2 : Anfragen Accepten oder Denien
Nachdem eine Person (Passagier) sich für eine Tour gemeldet hat, hat der Fahrer zwei Möglichkeiten, entweder er Aktzeptiert oder Verweigert die Mitfahrmöglichkeit
In beiden Fällen muss er das `PassengerRequest` Model zurück senden
<br/>
Die Api Calls wären `PUT AcceptRequest` und `PUT DenyRequest`
#### Model
```json
[
    {
        "id": "id",
        "idPerson": "idPerson",
        "idTourPlan": "idTourPlan",
        "message": "Stehe an der Ecke",
        "currentLatitude": 0,
        "currentLongitude": 0,
        "isPending": true,
        "isDenied": false,
        "person": {
            "firstname": "Passenger1_Firstname",
            "lastname": "Lastname_Passenger1",
            "email": "Passenger1@udrive.de",
            "phoneNumber": "number",

            ...
        },
        "tourPlan": null
    }
]
 ```

