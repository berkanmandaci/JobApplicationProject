import axios from 'axios';


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

// Tüm görevleri getir
export async function getTasks() {
  const response = await axios.get(`${API_URL}/TaskItems`);
  return response.data;
}

// Tek bir görevi getir
export async function getTask(id) {
  const response = await axios.get(`${API_URL}/TaskItems/${id}`);
  return response.data;
}

// Görev ekle
export async function createTask(task) {
  const response = await axios.post(`${API_URL}/TaskItems`, task);
  return response.data;
}

// Görev güncelle
export async function updateTask(id, task) {
  const response = await axios.put(`${API_URL}/TaskItems/${id}`, task);
  return response.data;
}

// Görev sil
export async function deleteTask(id) {
  await axios.delete(`${API_URL}/TaskItems/${id}`);
} 