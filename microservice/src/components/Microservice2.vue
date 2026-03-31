<template>
    <div>
        <h2>Microservice</h2>

        <button @click="callApi">
            {{ type === "orders" ? "Create Order" : "Make Payment" }}
        </button>

        <p v-if="loading">Loading...</p>

        <p v-if="error" style="color:red">{{ error }}</p>

        <p v-if="data">
            {{ type }} → {{ data }}
        </p>
    </div>
</template>

<script setup>
import { ref } from "vue";
import { createOrder, createPayment } from "../services/api";

const props = defineProps({
  type: String
});

const data = ref(null);
const error = ref("");
const loading = ref(false);

const callApi = async () => {
  loading.value = true;
  error.value = "";
  data.value = null;

  try {
    if (props.type === "orders") {
      const res = await createOrder({});
      data.value = res.data;
    } else if (props.type === "payments") {
      const res = await createPayment({});
      data.value = res.data;
    }
  } catch (err) {
    console.error(err);
    error.value = "Failed to fetch data.";
  } finally {
    loading.value = false;
  }
};
</script>

<style scoped>
/* same styles as before */
.result p {
  white-space: pre-line;
}
.error {
  color: #dc2626;
}
</style>