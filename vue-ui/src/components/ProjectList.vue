<template>
  <table class="table table-bordered">
    <thead>
      <tr>
        <th>#</th>
        <th>Proje Adı</th>
        <th>Açıklama</th>
        <th>İşlemler</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="project in projects" :key="project.id">
        <td>{{ project.id }}</td>
        <td>{{ project.name }}</td>
        <td>{{ project.description }}</td>
        <td>
          <router-link :to="`/projects/${project.id}/tasks`" class="btn btn-sm btn-primary me-2">
            <i class="bi bi-list-task"></i> Görevler
          </router-link>
          <button class="btn btn-sm btn-info me-2" @click="$emit('edit', project)">Düzenle</button>
          <button class="btn btn-sm btn-danger" @click="$emit('delete', project.id)">Sil</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  props: ['projects']
};
</script> 