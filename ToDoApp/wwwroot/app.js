// const apiBase = 'https://localhost:5001/api/todo';
const apiBase = '/api/todo';

// Fetch all todos from the API.
// Returns an array of TodoItemDto or an empty array on failure.
async function fetchTodos() {
  const res = await fetch(apiBase);
  if (!res.ok) return [];
  return res.json();
}

// Create a new todo. Sends a TodoItemDto with description and isDone.
// We return the parsed JSON result so the caller can use the created id.
async function createTodo(description) {
  const res = await fetch(apiBase, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ description: description, isDone: false })
  });

  if (!res.ok) {
    // Try to surface server errors to the UI
    const text = await res.text();
    throw new Error(`Failed to create todo: ${res.status} ${text}`);
  }

  return res.json();
}

// Update an existing todo by id. 
// This function will throw on non-2xx responses so callers can handle errors.
async function updateTodo(id, dto) {
  const res = await fetch(`${apiBase}/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(dto)
  });

  if (!res.ok) {
    const text = await res.text();
    throw new Error(`Failed to update todo: ${res.status} ${text}`);
  }
}