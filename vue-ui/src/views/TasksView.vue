<template>
  <div class="container mt-4">
    <h2>Görevler</h2>
    <button class="btn btn-primary mb-3" @click="showAddForm = true">Yeni Görev Ekle</button>
    <TaskForm v-if="showAddForm" :projectId="projectId" @saved="onTaskSaved" @cancel="showAddForm = false" />
    <TaskList :tasks="tasks" @edit="onEditTask" @delete="onDeleteTask" />
    <TaskForm v-if="editTask" :projectId="projectId" :task="editTask" @saved="onTaskUpdated" @cancel="editTask = null" />
    <router-link :to="'/projects'" class="btn btn-secondary mt-3">Projeler Listesine Dön</router-link>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { getTasksByProject, deleteTask } from '../services/api';
import TaskList from '../components/TaskList.vue';
import TaskForm from '../components/TaskForm.vue';
import { useRoute } from 'vue-router';

export default {
  components: { TaskList, TaskForm },
  setup() {
    const route = useRoute();
    const projectId = Number(route.params.projectId);
    const tasks = ref([]);
    const showAddForm = ref(false);
    const editTask = ref(null);

    async function loadTasks() {
      tasks.value = await getTasksByProject(projectId);
    }

    function onTaskSaved() {
      showAddForm.value = false;
      loadTasks();
    }

    function onEditTask(task) {
      editTask.value = { ...task };
    }

    function onTaskUpdated() {
      editTask.value = null;
      loadTasks();
    }

    async function onDeleteTask(taskId) {
      if (confirm('Bu görevi silmek istediğinize emin misiniz?')) {
        await deleteTask(projectId, taskId);
        loadTasks();
      }
    }

    onMounted(loadTasks);

    return { tasks, showAddForm, editTask, projectId, onTaskSaved, onEditTask, onTaskUpdated, onDeleteTask };
  }
};
</script> 