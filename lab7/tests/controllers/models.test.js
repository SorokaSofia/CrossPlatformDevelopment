const request = require("supertest");
const { expect } = require("chai");

describe("Models API", () => {
  const baseUrl = "http://localhost:5192/api";

  it("should fetch all models", async () => {
    const response = await request(baseUrl).get("/models").expect(200);
    expect(response.body).to.be.an("array");
  });

  it("should fetch a model by code", async () => {
    const testCode = "X5"; // Змініть на наявний код моделі
    const response = await request(baseUrl).get(`/models/${testCode}`).expect(200);
    expect(response.body).to.have.property("modelCode", testCode);
  });

  it("should return 404 for a non-existent model", async () => {
    const invalidCode = "InvalidCode"; // Невірний код
    await request(baseUrl).get(`/models/${invalidCode}`).expect(404);
  });
});
