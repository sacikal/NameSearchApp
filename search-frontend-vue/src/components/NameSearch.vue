<!-- src/components/Search.vue -->
<template>
  <div>
    <input v-model="searchTerm" type="text" />
    <button @click="handleSearch">Search</button>
    <div v-if="searchResults.length > 0">
      <ul>
        <li v-for="person in searchResults" :key="person.id">{{ person.firstName }} {{ person.lastName }}</li>
      </ul>
    </div>
  </div>
</template>
  
<script>
export default {
  data() {
    return {
      searchTerm: '',
      searchResults: []
    };
  },
  methods: {
    async handleSearch() {
      try {
        const response = await fetch(`https://localhost:5000/api/search?term=${this.searchTerm}`);
        const data = await response.json();
        this.searchResults = data;

        // Show alert if no records are found
        if (this.searchResults.length === 0) {
          this.showAlert("No records are found");
        }

        if (response && response.status === 400) {
          // Handle HTTP 400 error
          this.showAlert("You did not provide a search input and no results should be returned.");
        }

      } catch (error) {
        console.error("An error occured", error)
      }
    },

    showAlert(message) {
      alert(message);
    }
  },
};
</script>
