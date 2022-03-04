# Phase 2, planning

Questions:
	- The new feature will need pagination like the homepage?
	- Do we need to send notifications to the user when someone replies to the post?

Changes in the Database:
	- Create a new column in the table "Posts" called "ReplyToPostId".
		- This new column is a reference to the Table "Posts", column "Id".		
		- column details: 
			- type: int.
			- nullable: yes.		
		
Changes in the API:
	- Map a new column in the Models;
	- Create a new method responsible for handling the replies.
	
Changes in the Front-end:
	- Create a new page responsible for showing the replies.
	- Create a new component responsible for getting the response from the user.
	
	

