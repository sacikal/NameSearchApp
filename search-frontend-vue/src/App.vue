<!-- src/App.vue -->
<template>
  <div>
    <h1>Search App</h1>
    <NameSearch />
  </div>
</template>

<script>
import NameSearch from './components/NameSearch.vue';

export default {
  components: {
    NameSearch,
  },
};
</script>

<style>
/* Add your styles here */
</style>
