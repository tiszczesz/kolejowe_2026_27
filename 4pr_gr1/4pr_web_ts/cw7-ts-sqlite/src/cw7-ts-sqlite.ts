import {type Course,openDb,getCourses, getCourseById, insertBook, deleteCourse, updateCourse} from './repoSqlite.js';
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
    const courseDate = await rl.question("data kursu: YYYY-MM-DD ");
    const newCourse:Course = {
        id: 0,
        title: courseTitle,
        price: coursePrice,
        date_start: courseDate
    }
    insertBook(db,newCourse);
    console.log("Dodano nowy kurs!");
    
}
const deleteQuestion = await rl.question("Czy chcesz usunąć kurs? (t/n): ");
if (deleteQuestion === 't') {
    const deleteId = await rl.question("Podaj ID kursu do usunięcia: ");
    const idToDelete = parseInt(deleteId);
    const courseToDelete = getCourseById(db, idToDelete);
    if (courseToDelete) {
        deleteCourse(db, idToDelete);
        console.log("Kurs usunięty!");
    } else {
        console.log("Kurs nie znaleziony.");
    }
}
const updateQuestion = await rl.question("Czy chcesz zaktualizować kurs? (t/n): ");
if (updateQuestion === 't') {
    const updateId = await rl.question("Podaj ID kursu do aktualizacji: ");
    const idToUpdate = parseInt(updateId);
    const courseToUpdate = getCourseById(db, idToUpdate);
    if (courseToUpdate) {
        const newTitle = (  await rl.question("Podaj nową nazwę kursu: ")) || courseToUpdate.title;
        const newPrice = parseFloat(await rl.question("Podaj nową cenę kursu: ")) || courseToUpdate.price;
        const newDate = await rl.question("Podaj nową datę kursu: YYYY-MM-DD ")|| courseToUpdate.date_start;
        const updatedCourse: Course = {
            id: idToUpdate,
            title: newTitle,
            price: newPrice,
            date_start: newDate
        };
        updateCourse(db, updatedCourse);
        console.log("Kurs zaktualizowany!");
    } else {
        console.log("Kurs nie znaleziony.");
    }
}
rl.close();