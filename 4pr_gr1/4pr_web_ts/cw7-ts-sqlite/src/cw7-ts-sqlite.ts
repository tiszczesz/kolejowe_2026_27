import {type Course,openDb,getCourses, getCourseById} from './repoSqlite.js';
import * as readline from 'node:readline/promises';

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Open the database 
const db = openDb();
console.log("Database opened successfully.");
console.log(db);

// Retrieve courses from the database
const courses = getCourses(db);
console.log("Courses retrieved successfully.");
console.log(courses);

// Get a specific course by ID
const courseId = await rl.question("Enter course ID: ");
const course = getCourseById(db, parseInt(courseId));
if (course) {
    console.log("Course found:");
    console.log(course);
} else {
    console.log("Course not found.");
}
rl.close();