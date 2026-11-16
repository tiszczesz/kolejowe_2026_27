import {type Course,openDb,getCourses, getCourseById, insertBook} from './repoSqlite.js';
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
const choice = await rl.question("Czy dodać nowy kurs? (t/n): ")
if(choice==='t'){
    const courseTitle = await rl.question("nazwa kursu: ");
    const coursePrice = parseFloat(await rl.question("cena kursu: "));
    const courseDate = await rl.question("data kursu: ");
    const newCourse:Course = {
        id: 0,
        title: courseTitle,
        price: coursePrice,
        date_start: courseDate
    }
    insertBook(db,newCourse);
    console.log("Dodano nowy kurs!");
    
}
rl.close();