<template>
  <div class="card mb-3">
    <div class="card-body">
      <h5 class="card-title">{{ project && project.id ? 'Projeyi Güncelle' : 'Yeni Proje Ekle' }}</h5>
      <form @submit.prevent="onSubmit">
        <div class="mb-3">
          <label class="form-label">Proje Adı</label>
          <input v-model="form.name" type="text" class="form-control" required />
        </div>
        <div class="mb-3">
          <label class="form-label">Açıklama</label>
          <textarea v-model="form.description" class="form-control" rows="2"></textarea>
        </div>
        <button type="submit" class="btn btn-success me-2">Kaydet</button>
        <button type="button" class="btn btn-secondary" @click="$emit('cancel')">İptal</button>
      </form>
    </div>
  </div>
</template>

<script>
import { ref, watch, onMounted } from 'vue';
import { createProject, updateProject } from '../services/api';

export default {
  props: ['project'],
  setup(props, { emit }) {
    const form = ref({ name: '', description: '' });

    watch(() => props.project, (newVal) => {
      if (newVal) {
        form.value = { name: newVal.name, description: newVal.description, id: newVal.id };
      } else {
        form.value = { name: '', description: '' };
      }
    }, { immediate: true });

    async function onSubmit() {
      if (form.value.id) {
        await updateProject(form.value.id, form.value);
      } else {
        await createProject(form.value);
      }
      emit('saved');
    }

    return { form, onSubmit };
  }
};
</script> 