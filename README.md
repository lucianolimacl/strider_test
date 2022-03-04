# Phase 2, planning

Questions:<br/>
	- The new feature will need pagination like the homepage?<br/>
	- Do we need to send notifications to the user when someone replies to the post?<br/>

Changes in the Database:
	- Create a new column in the table "Posts" called "ReplyToPostId".<br/>
		- This new column is a reference to the Table "Posts", column "Id".<br/>		
		- column details:<br/> 
			- type: int.<br/>
			- nullable: yes.<br/>		
		
Changes in the API:<br/>
	- Map a new column in the Models;<br/>
	- Create a new method responsible for handling the replies.<br/>
	
Changes in the Front-end:<br/>
	- Create a new page responsible for showing the replies.<br/>
	- Create a new component responsible for getting the response from the user.<br/>
	
	

