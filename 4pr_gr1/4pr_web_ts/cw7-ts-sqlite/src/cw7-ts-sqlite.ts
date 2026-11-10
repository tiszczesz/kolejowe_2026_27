import {type Course,openDb,getCourses} from './repoSqlite.js';

// Open the database 
const db = openDb();
console.log("Database opened successfully.");
console.log(db);

// Retrieve courses from the database
const courses = getCourses(db);
console.log("Courses retrieved successfully.");
console.log(courses);