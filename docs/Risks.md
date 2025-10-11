# Risques du domaine

Ce fichier documente les **principaux risques associés à ce domaine**.  
Chaque risque est lié à l’entité, la fonctionnalité ou le processus concerné.

## Risque 1 : Calcul de prix incorrect

**Catégorie** : Logique métier  
**Impact** : Élevé  
**Probabilité** : Moyenne  
**Mesures de mitigation** : Implémenter des tests unitaires et valider tous les cas limites dans l’agrégat `OrderAggregate`.  
**Entité/Fonctionnalité associée** : Commande, Money

## Risque 2 : Incohérence des données entre systèmes

**Catégorie** : Intégration  
**Impact** : Élevé  
**Probabilité** : Élevée  
**Mesures de mitigation** : Utiliser une synchronisation événementielle avec vérification de cohérence éventuelle.  
**Entité/Fonctionnalité associée** : Client, Commande

## Risque 3 : Accès non autorisé à des données sensibles

**Catégorie** : Sécurité  
**Impact** : Critique  
**Probabilité** : Moyenne  
**Mesures de mitigation** : Appliquer un contrôle d’accès basé sur les rôles (RBAC), chiffrer les champs sensibles et auditer les accès.  
**Entité/Fonctionnalité associée** : Client, PaymentInfo
