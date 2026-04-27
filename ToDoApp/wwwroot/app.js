// const apiBase = 'https://localhost:5001/api/todoitems';
const apiBase = '/api/todoitems';

// Fetch all todos from the API.
// Returns an array of TodoItemDto or an empty array on failure.
async function fetchTodos() {
    const res = await fetch(apiBase);
    if (!res.ok) return [];
    return res.json();
}