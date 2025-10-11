# Scénarios BDD du domaine

Ce fichier décrit les **scénarios comportementaux (Behavior-Driven Development)** associés à ce domaine.  
Chaque scénario illustre un comportement métier attendu, exprimé sous la forme **En tant que / Quand / Alors**, afin d’assurer une compréhension commune entre les équipes métier et techniques.

---

## 🧩 Fonctionnalité : Passer une commande

```gherkin
Fonctionnalité : Passer une commande

  En tant que client authentifié
  Je veux pouvoir passer une commande contenant des produits disponibles
  Afin d’obtenir une confirmation et que la commande soit enregistrée

  Scénario : Passer une commande avec succès
    Étant donné qu’un client a ajouté un produit disponible à son panier
    Et qu’il dispose d’un moyen de paiement valide
    Quand il confirme sa commande
    Alors une commande est créée avec l’état "En cours"
    Et un événement "OrderPlaced" est publié
```

**Entités concernées :** Customer, Order, Product
**Commandes associées :** PlaceOrderCommand
**Événements associés :** OrderPlacedEvent

## 🧩 Fonctionnalité : Gestion du stock

```gherkin
Fonctionnalité : Gestion du stock

  En tant que client
  Je veux être informé si un produit n’est plus disponible
  Afin d’éviter de passer une commande invalide

  Scénario : Refus de commande pour stock insuffisant
    Étant donné qu’un produit n’a plus de stock disponible
    Quand un client tente de passer une commande incluant ce produit
    Alors la commande est refusée
    Et un message d’erreur "Stock insuffisant" est affiché
```

**Entités concernées :** Product, Order
**Commandes associées :** PlaceOrderCommand
**Événements associés :** OrderRejectedEvent

## 🧩 Fonctionnalité : Annulation d’une commande

```gherkin
Fonctionnalité : Annulation d’une commande

  En tant que client
  Je veux pouvoir annuler une commande en cours
  Afin de corriger une erreur ou changer d’avis avant expédition

  Scénario : Annuler une commande en cours
    Étant donné qu’une commande existe avec l’état "En cours"
    Et que le client est le propriétaire de cette commande
    Quand il demande son annulation
    Alors la commande passe à l’état "Annulée"
    Et un événement "OrderCancelled" est publié
```

**Entités concernées :** Order, Customer
**Commandes associées :** CancelOrderCommand
**Événements associés :** OrderCancelledEvent

## 🧩 Fonctionnalité : Mise à jour des informations client

```gherkin
Fonctionnalité : Mise à jour des informations client

  En tant que client
  Je veux pouvoir modifier mon adresse ou mes informations de contact
  Afin de recevoir mes commandes au bon endroit

  Scénario : Mise à jour de l’adresse d’un client
    Étant donné qu’un client possède un compte existant
    Quand il met à jour son adresse postale
    Alors les nouvelles informations sont enregistrées
    Et un événement "CustomerAddressUpdated" est publié
```

**Entités concernées :** Customer
**Commandes associées :** UpdateCustomerAddressCommand
**Événements associés :** CustomerAddressUpdatedEvent