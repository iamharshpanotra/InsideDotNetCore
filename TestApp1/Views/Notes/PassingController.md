# Passing Data from Controller to View. 
	- Following objects can be used to pass data between controller and view. 
		1. ViewData
		2. ViewBag
		3. TempData
		4. Strongly Typed View

# ViewData
	- It passes data from a Controller to a View. 
		ViewData["<Key>"]= <Value>;
		where,
	- Key: Is a string value to identify the object present in VIewData. 
	- Value: Is the object present in VD. This object may be a String, object, list, array
			 or a different type, such as int, char, float, double DateTime etc. 
