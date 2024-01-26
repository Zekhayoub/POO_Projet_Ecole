# Programmation orientée objet Projet Ecole
Projet 2023 - École


A faire:
-  [x] de créer des enseignants,
-  [ ] de créer des activités,
-  [ ] de relier les activités aux enseignants,
-  [x] de créer des étudiants, d'ajouter une évaluation pour un cours créer pour un étudiant (cote ou appréciation),
-  [x] d'afficher le bulletin des étudiants
-  [ ] Sauvegarde d'étudiants: 1 points
-  [ ] Sauvegarde d'enseignants: 1 points
-  [ ] Sauvegarde d'activités: 1 points
-  [ ] Sauvegarde d'évaluations: 2 points
-  [ ] Bulletin: 2 points
-  [ ] Défaut d'encapsulation: jusqu'à -4 points
-  [ ] Défaut de factorisation: jusqu'à -4 points
-  [ ] Diagramme UML: 4 points
-  [ ] Principes SOLID: 4 point

![image](https://github.com/Zekhayoub/POO_Projet_Ecole/assets/124704424/f9971e08-9de0-4794-9076-f8676a880d08)
(image 1)
![image](https://github.com/Zekhayoub/POO_Projet_Ecole/assets/124704424/0b0ca54c-00da-4c0f-a572-39850fba6d4f)
(image 2)
### 0. Description du projet 
Le programme permet de simuler une application de gestion d'école. premièrement la page de garde possède un bouton (image 1) qui amène à une page de gestion d'étudiants(image 2). Dans la page de gestion d'étudiants on peut créer une note pour un élève en précisant le nom de l'élève dans le premier champ et ensuite on peut y mettre la matière et la note correspond. Comme fonctionnalité additionnelle, nous pouvons ajouter une description à la note de l'élève permettant de préciser si celui-ci a bien travaillée ou si il a été dissipé.

### 1. Diagramme UML

### 2. Principes SOLID
Comme principe solide respecté, nous pouvons parler du single responsability principle et de l'open closed principle les autres principes étant respecté puisque non utilisé.

Premièrement pour le Single responsabilty, toutes les méthodes employées dans la classe principales ne servent qu'à une seule et seule choses, la création de directory ne sert qu'à une seule chose, la sauvegarde et le chargement des notes de mêmes. Le principe est donc bien respecté.

Deuxièment pour le open/closed principle, le code est ouvert à l'extension et fermé à la modification en effet, il est simple de rajouter des méthodes dans la classe principal. la modification est plus compliqué car quasi impossible en dehors de la classe de par l'attribut privé de toutes les variables d'instances et de par l'encapsulation respecté partout.
