import { createRouter, createWebHistory } from 'vue-router';
import ProjectsView from './views/ProjectsView.vue';
import TasksView from './views/TasksView.vue';

const routes = [
  { path: '/', redirect: '/projects' },
  { path: '/projects', component: ProjectsView },
  { path: '/projects/:projectId/tasks', component: TasksView, props: true },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router; 