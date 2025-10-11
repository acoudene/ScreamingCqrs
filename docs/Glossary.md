# Glossary (Ubiquitous Language)

Ce fichier définit le **vocabulaire métier** officiel de la solution.  
Il sert à aligner développeurs et métiers et à faciliter la lecture et la maintenance du code.

## 🏷️ Entités (Entities)

Objets ayant une **identité unique et un cycle de vie propre**.

| Entité | Description | Identifiant |
|--------|-------------|------------|
| Order | Représente une commande passée par un client | `OrderId` |
| Customer | Représente un client pouvant passer des commandes | `CustomerId` |
| Product | Représente un produit dans le catalogue | `ProductId` |

## 🎯 Valeurs (Value Objects)

Objets définis par **leurs attributs**, immuables et sans identité propre.

| Valeur | Description | Exemple d’utilisation |
|--------|-------------|---------------------|
| Money | Représente un montant monétaire avec devise | `Money(Amount: 100, Currency: USD)` |
| Address | Adresse complète d’un client | `Address(Street, City, Zip, Country)` |
| Email | Adresse email valide | `Email("john.doe@example.com")` |

## 📂 Agrégats (Aggregates)

Groupes d’entités et de valeurs cohérents, traités comme **un seul point de modification**.

| Agrégat | Racine | Contenu |
|---------|--------|--------|
| OrderAggregate | Order | OrderLines, CustomerReference, PaymentInfo |
| CustomerAggregate | Customer | Address, Email, LoyaltyPoints |

## 📦 Commandes (Commands)

Représentent des **actions initiées par l’utilisateur ou un système**, généralement nommées avec un verbe.

| Commande | Description | Exemple de classe |
|----------|-------------|-----------------|
| PlaceOrder | Crée une nouvelle commande pour un client | `PlaceOrderCommand` |
| CancelOrder | Annule une commande existante | `CancelOrderCommand` |
| UpdateCustomerAddress | Met à jour l’adresse d’un client | `UpdateCustomerAddressCommand` |

## 📌 Événements (Events)

Représentent des **changements d’état significatifs** dans le domaine, produits après l’exécution d’une commande.

| Événement | Description | Exemple de classe |
|-----------|-------------|-----------------|
| OrderPlaced | Une commande a été passée avec succès | `OrderPlacedEvent` |
| OrderCancelled | Une commande a été annulée | `OrderCancelledEvent` |
| CustomerAddressUpdated | L’adresse d’un client a été modifiée | `CustomerAddressUpdatedEvent` |

## 💡 Bonnes pratiques pour ce fichier

1. Mettre à jour **en même temps que le code** pour éviter la dérive.  
2. Ajouter des exemples concrets de classes ou noms dans le code.  
3. Garder la structure simple : Commandes, Événements, Entités, Valeurs, Agrégats.  
4. Ajouter un **lien vers ce fichier dans le README.md** pour le rendre facilement accessible.


