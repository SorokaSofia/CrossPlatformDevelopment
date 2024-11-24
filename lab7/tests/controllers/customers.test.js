const request = require("supertest");
const { expect } = require("chai");

describe("Customers API", () => {
  const baseUrl = "http://localhost:5192/api";

  it("should fetch all customers", async () => {
    const response = await request(baseUrl).get("/customers").expect(200);
    expect(response.body).to.be.an("array");
  });

  it("should fetch a customer by ID", async () => {
    const testId = 1; // Змініть на наявний ID
    const response = await request(baseUrl).get(`/customers/${testId}`).expect(200);
    expect(response.body).to.have.property("customerId", testId);
  });

  it("should return 404 for a non-existent customer", async () => {
    const invalidId = 9999; // Невірний ID
    await request(baseUrl).get(`/customers/${invalidId}`).expect(404);
  });
});
