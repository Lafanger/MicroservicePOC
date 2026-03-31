<template>
    <div>
        <!-- Tabs -->
        <div class="tabs">
            <button :class="{ active: activeTab === 'orders' }"
                    @click="activeTab = 'orders'">
                Orders
            </button>

            <button :class="{ active: activeTab === 'payments' }"
                    @click="activeTab = 'payments'">
                Payments
            </button>
        </div>

        <!-- Content -->
        <div class="content">
            <Microservice2 v-if="activeTab === 'orders'" type="orders" />
            <Microservice2 v-if="activeTab === 'payments'" type="payments" />
        </div>
    </div>
</template>

<script setup>
import { ref } from 'vue'
import Microservice2 from './components/Microservice2.vue'

const activeTab = ref('orders') // default tab
</script>

<style scoped>
    .tabs {
        display: flex;
        gap: 10px;
        margin-bottom: 20px;
    }

        .tabs button {
            padding: 10px 16px;
            border: none;
            background: #ddd;
            cursor: pointer;
            border-radius: 6px;
        }

            .tabs button.active {
                background: #007bff;
                color: white;
            }

    .content {
        padding: 10px;
    }
</style>