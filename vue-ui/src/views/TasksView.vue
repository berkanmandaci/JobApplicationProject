<template>
  <div class="container mt-4">
    <h2>Görevler</h2>
    <button class="btn btn-primary mb-3" @click="showAddForm = true">Yeni Görev Ekle</button>
    <TaskForm v-if="showAddForm" :projectId="projectId" @saved="onTaskSaved" @cancel="showAddForm = false" />
    <TaskList :tasks="tasks" @edit="onEditTask" @delete="onDeleteTask" @status-change="onStatusChange" />
    <TaskForm v-if="editTask" :projectId="projectId" :task="editTask" @saved="onTaskUpdated" @cancel="editTask = null" />
    <router-link :to="'/projects'" class="btn btn-secondary mt-3">Projeler Listesine Dön</router-link>
  </div>
</template>

<script>
import { ref, onMounted, watch } from 'vue';
import { getTasks, deleteTask, updateTask } from '../services/api';
import TaskList from '../components/TaskList.vue';
import TaskForm from '../components/TaskForm.vue';
import { useRoute } from 'vue-router';

export default {
  components: { TaskList, TaskForm },
  props: {
    projectId: {
      type: [String, Number],
      required: false
    }
  },
  setup(props) {
    const route = useRoute();
    const projectId = ref(props.projectId ? Number(props.projectId) : Number(route.params.projectId));
    const tasks = ref([]);
    const showAddForm = ref(false);
    const editTask = ref(null);

    async function loadTasks() {
      // Artık sadece tüm görevleri çekiyoruz, filtreleme gerekiyorsa burada yapılmalı
      const allTasks = await getTasks();
      // Eğer sadece ilgili projenin görevleri gösterilecekse:
      if (projectId.value) {
        tasks.value = allTasks.filter(t => t.projectId == projectId.value);
      } else {
        tasks.value = allTasks;
      }
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
        await deleteTask(taskId);
        loadTasks();
      }
    }

    async function onStatusChange(task) {
      // isComplete değerini tersine çevir
      const updatedTask = { ...task, isComplete: !task.isComplete };
      await updateTask(task.id, updatedTask);
      loadTasks();
    }

    watch(() => props.projectId, (newVal) => {
      if (newVal) {
        projectId.value = Number(newVal);
        loadTasks();
      }
    });

    onMounted(loadTasks);

    return { tasks, showAddForm, editTask, projectId, onTaskSaved, onEditTask, onTaskUpdated, onDeleteTask, onStatusChange };
  }
};
</script> 