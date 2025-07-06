<template>
  <div class="card mb-3">
    <div class="card-body">
      <h5 class="card-title">{{ task && task.id ? 'Görevi Güncelle' : 'Yeni Görev Ekle' }}</h5>
      <form @submit.prevent="onSubmit">
        <div class="mb-3">
          <label class="form-label">Başlık</label>
          <input v-model="form.title" type="text" class="form-control" required />
        </div>
        <div class="mb-3">
          <label class="form-label">Açıklama</label>
          <textarea v-model="form.description" class="form-control" rows="2"></textarea>
        </div>
        <div class="mb-3">
          <label class="form-label">Durum</label>
          <select v-model="form.isCompleted" class="form-select">
            <option :value="false">Bekliyor</option>
            <option :value="true">Tamamlandı</option>
          </select>
        </div>
        <button type="submit" class="btn btn-success me-2">Kaydet</button>
        <button type="button" class="btn btn-secondary" @click="$emit('cancel')">İptal</button>
      </form>
    </div>
  </div>
</template>

<script>
import { ref, watch } from 'vue';
import { createTask, updateTask } from '../services/api';

export default {
  props: ['projectId', 'task'],
  setup(props, { emit }) {
    const form = ref({ title: '', description: '', isCompleted: false });

    watch(() => props.task, (newVal) => {
      if (newVal) {
        form.value = { title: newVal.title, description: newVal.description, isCompleted: newVal.isCompleted, id: newVal.id };
      } else {
        form.value = { title: '', description: '', isCompleted: false };
      }
    }, { immediate: true });

    async function onSubmit() {
      if (form.value.id) {
        await updateTask(props.projectId, form.value.id, form.value);
      } else {
        await createTask(props.projectId, form.value);
      }
      emit('saved');
    }

    return { form, onSubmit };
  }
};
</script> 