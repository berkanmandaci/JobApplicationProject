<template>
  <table class="table table-bordered">
    <thead>
      <tr>
        <th>#</th>
        <th>Başlık</th>
        <th>Durum</th>
        <th>İşlemler</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="task in tasks" :key="task.id">
        <td>{{ task.id }}</td>
        <td>{{ task.name }}</td>
        <td>
          <input
            type="checkbox"
            :checked="task.isComplete"
            @change="$emit('status-change', task)"
          />
        </td>
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