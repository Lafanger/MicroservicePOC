import axios from "axios";

const isLocal = import.meta.env.DEV;

// LOCAL URLs
const ordersUrl = isLocal
  ? import.meta.env.VITE_API_ORDERS_URL
  : import.meta.env.VITE_API_BASE_URL;

const paymentsUrl = isLocal
  ? import.meta.env.VITE_API_PAYMENTS_URL
  : import.meta.env.VITE_API_BASE_URL;

// Headers (only needed in Azure)
const headers = {
  "Ocp-Apim-Subscription-Key": import.meta.env.VITE_APIM_KEY || ""
};

// Orders
export const createOrder = (data) =>
  axios.post(`${ordersUrl}/orders`, data, { headers });

// Payments
export const createPayment = (data) =>
  axios.post(`${paymentsUrl}/payments`, data, { headers });