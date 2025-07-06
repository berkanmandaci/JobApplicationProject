<template>
  <table class="table table-bordered">
    <thead>
      <tr>
        <th>#</th>
        <th>Başlık</th>
        <th>Açıklama</th>
        <th>Durum</th>
        <th>İşlemler</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="task in tasks" :key="task.id">
        <td>{{ task.id }}</td>
        <td>{{ task.title }}</td>
        <td>{{ task.description }}</td>
        <td>{{ task.isCompleted ? 'Tamamlandı' : 'Bekliyor' }}</td>
        <td>
          <button class="btn btn-sm btn-info me-2" @click="$emit('edit', task)">Düzenle</button>
          <button class="btn btn-sm btn-danger" @click="$emit('delete', task.id)">Sil</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  props: ['tasks']
};
</script> 