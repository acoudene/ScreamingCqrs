# Sequence diagram

```mermaid
sequenceDiagram
    participant API
    participant Application
    participant Domain
    participant Infrastructure

    API->>Application: POST /orders
    Application->>Domain: CreateOrder()
    Domain-->>Application: OrderCreated
    Application->>Infrastructure: SaveToDb()
    Infrastructure-->>API: 201 Created
```