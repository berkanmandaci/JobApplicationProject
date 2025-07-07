<template>
  <div class="container mt-4">
    <h2>Projeler</h2>
    <p class="text-muted">Bir projenin görevlerini görmek için ilgili satırdaki <b>Görevler</b> butonuna tıklayın.</p>
    <button class="btn btn-primary mb-3" @click="showAddForm = true">Yeni Proje Ekle</button>
    <ProjectForm v-if="showAddForm" @saved="onProjectSaved" @cancel="showAddForm = false" />
    <ProjectList :projects="projects" @edit="onEditProject" @delete="onDeleteProject" />
    <ProjectForm v-if="editProject" :project="editProject" @saved="onProjectUpdated" @cancel="editProject = null" />
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { getProjects, deleteProject } from '../services/api';
import ProjectList from '../components/ProjectList.vue';
import ProjectForm from '../components/ProjectForm.vue';

export default {
  components: { ProjectList, ProjectForm },
  setup() {
    const projects = ref([]);
    const showAddForm = ref(false);
    const editProject = ref(null);

    async function loadProjects() {
      projects.value = await getProjects();
    }

    function onProjectSaved() {
      showAddForm.value = false;
      loadProjects();
    }

    function onEditProject(project) {
      editProject.value = { ...project };
    }

    function onProjectUpdated() {
      editProject.value = null;
      loadProjects();
    }

    async function onDeleteProject(id) {
      if (confirm('Bu projeyi silmek istediğinize emin misiniz?')) {
        await deleteProject(id);
        loadProjects();
      }
    }

    onMounted(loadProjects);

    return { projects, showAddForm, editProject, onProjectSaved, onEditProject, onProjectUpdated, onDeleteProject };
  }
};
</script> 