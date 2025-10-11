# Prerequisites

VSCode with extension: Markdown Preview Enhanced.

Markdown-preview-enhanced: Plantuml Server
Render using PlantUML server instead of binary. Leave it empty to use the builtin plantuml.jar binary (`java` is required in system path). Eg: "http://localhost:8080/svg/": https://kroki.io/plantuml/svg/

# Use cases

```plantuml
@startuml
title Use Case Diagram — Hexagonal Architecture (CQRS Oriented)

left to right direction

actor "Utilisateur" as User
actor "Administrateur" as Admin
actor "Système Externe\n(Paiement, ERP...)" as ExternalSystem

rectangle "Application (Ports Primaires)" {
    usecase "Créer une commande" as UC_CreateOrder
    usecase "Consulter les commandes" as UC_ViewOrders
    usecase "Annuler une commande" as UC_CancelOrder
    usecase "Synchroniser les paiements" as UC_SyncPayments
}

rectangle "Domain (Modèle Métier)" {
    usecase "Valider la commande" as UC_ValidateOrder
    usecase "Calculer le total" as UC_CalcTotal
    usecase "Publier un événement OrderCreated" as UC_PublishEvent
}

rectangle "Infrastructure (Adapters / Ports Secondaires)" {
    usecase "Persister commande" as UC_SaveOrder
    usecase "Notifier le client" as UC_NotifyCustomer
    usecase "Appeler le système de paiement" as UC_CallPayment
}

' Relations externes
User --> UC_CreateOrder
User --> UC_ViewOrders
User --> UC_CancelOrder
Admin --> UC_ViewOrders
ExternalSystem --> UC_SyncPayments

' Relations internes (flux logique)
UC_CreateOrder --> UC_ValidateOrder
UC_CreateOrder --> UC_CalcTotal
UC_CreateOrder --> UC_SaveOrder
UC_CreateOrder --> UC_PublishEvent
UC_PublishEvent --> UC_NotifyCustomer
UC_SyncPayments --> UC_CallPayment

@enduml
```

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

```plantuml
@startuml
title Création d'une commande

actor "Client" as C
participant "API (Host)" as API
participant "Application Service" as APP
participant "Domain (Aggregate)" as DOMAIN
participant "Infrastructure (Repository)" as INFRA

C -> API : POST /orders
API -> APP : CreateOrder(command)
APP -> DOMAIN : new Order(...)
DOMAIN -> DOMAIN : validate()
DOMAIN -> INFRA : save(order)
INFRA --> APP : confirmation saved
APP --> API : return OrderCreatedResponse
API --> C : HTTP 201 Created

@enduml
```



