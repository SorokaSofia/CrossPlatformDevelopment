import request from "supertest";

const cleanup = async () => {
  const baseUrl = "http://localhost:5192/api";

  // Видалення тестових даних
  await request(baseUrl).delete("/customers/test-data").catch(() => {});
  await request(baseUrl).delete("/mechanics/test-data").catch(() => {});
  await request(baseUrl).delete("/models/test-data").catch(() => {});
};

export default cleanup;
