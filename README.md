# Programmation orientée objet Projet Ecole


## Description
ce projet vise à améliorer l'exercice du labo 2 en intégrant une interface moderne grâce à MAUI (Multi-platform App UI). Notre objectif principal est de simplifier la gestion des données liées à un établissement éducatif en permettant la création d'enseignants, d'activités, d'étudiants, et en facilitant la gestion des évaluations. En outre, nous cherchons à offrir une expérience utilisateur fluide en connectant les activités aux enseignants et en générant des bulletins détaillés pour les étudiants.

Les principales fonctionnalités de cette interface MAUI comprennent la création d'enseignants, la définition d'activités éducatives, l'association d'activités à des enseignants, la gestion d'étudiants, l'ajout d'évaluations (sous forme de cotes ou d'appréciations) pour des cours spécifiques, et enfin, l'affichage du bulletin complet des étudiants.

En réponse à la demande spécifique du projet, nous avons choisi d'ajouter une fonctionnalité supplémentaire particulièrement pertinente : la possibilité de laisser des commentaires généraux. Cette fonctionnalité permettra aux utilisateurs d'ajouter des remarques globales et des observations sur les enseignants, les activités ou les étudiants, contribuant ainsi à une communication plus riche et à une compréhension approfondie des performances éducatives.

## Quelques images de notre application


![image](https://github.com/Zekhayoub/POO_Projet_Ecole/assets/124704424/f9971e08-9de0-4794-9076-f8676a880d08)

![image](https://github.com/Zekhayoub/POO_Projet_Ecole/assets/124704424/0b0ca54c-00da-4c0f-a572-39850fba6d4f)



## Diagramme UML
### 1.  Diagramme de classes

### 2.  Diagramme de séquences
<p align="center">
  <img src="images/5.png" >
</p>




## 2. Principes SOLID

En ce qui concerne les principes SOLID, nous pouvons aborder le respect du principe de responsabilité unique et du principe ouvert/fermé.

### 1. Principe de responsabilité unique 
Premièrement, en ce qui concerne le principe de responsabilité unique, toutes les méthodes utilisées dans la classe principale sont dédiées à une seule et unique tâche. Par exemple, la création de répertoire ne sert qu'à cette tâche spécifique, tout comme la sauvegarde et le chargement des notes. Ainsi, le principe de responsabilité unique est respecté, garantissant un code clair et facile à maintenir.

### 2. open/closed principle
Deuxièmement, pour le principe ouvert/fermé, le code est conçu pour être ouvert à l'extension et fermé à la modification. Il est facile d'ajouter de nouvelles méthodes dans la classe principale pour étendre les fonctionnalités sans avoir à modifier le code existant. La modification du code existant est rendue complexe, voire quasi impossible à l'extérieur de la classe, en raison de l'utilisation d'attributs privés pour toutes les variables d'instances et du respect de l'encapsulation à tous les niveaux. Ainsi, le principe ouvert/fermé est également suivi, favorisant la flexibilité et la robustesse du système.

En résumé, notre approche dans la conception du programme témoigne du respect des principes SOLID, en particulier du principe de responsabilité unique et du principe ouvert/fermé, assurant ainsi un code structuré, évolutif et maintenable.
