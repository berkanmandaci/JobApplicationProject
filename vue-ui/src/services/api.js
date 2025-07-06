import axios from 'axios';

// API ana adresi (gerekirse portu ve adresi backend'e göre güncelle)
const API_URL = 'http://13.60.207.57:5000/api';

// Projeleri getir
export async function getProjects() {
  const response = await axios.get(`${API_URL}/projects`);
  return response.data;
}

// Proje ekle
export async function createProject(project) {
  const response = await axios.post(`${API_URL}/projects`, project);
  return response.data;
}

// Proje güncelle
export async function updateProject(id, project) {
  const response = await axios.put(`${API_URL}/projects/${id}`, project);
  return response.data;
}

// Proje sil
export async function deleteProject(id) {
  await axios.delete(`${API_URL}/projects/${id}`);
}

// Bir projeye ait görevleri getir
export async function getTasksByProject(projectId) {
  const response = await axios.get(`${API_URL}/projects/${projectId}/tasks`);
  return response.data;
}

// Görev ekle
export async function createTask(projectId, task) {
  const response = await axios.post(`${API_URL}/projects/${projectId}/tasks`, task);
  return response.data;
}

// Görev güncelle
export async function updateTask(projectId, taskId, task) {
  const response = await axios.put(`${API_URL}/projects/${projectId}/tasks/${taskId}`, task);
  return response.data;
}

// Görev sil
export async function deleteTask(projectId, taskId) {
  await axios.delete(`${API_URL}/projects/${projectId}/tasks/${taskId}`);
} 