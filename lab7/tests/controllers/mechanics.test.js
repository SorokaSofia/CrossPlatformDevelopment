const request = require("supertest");
const { expect } = require("chai");

describe("Mechanics API", () => {
  const baseUrl = "http://localhost:5192/api";

  it("should fetch all mechanics", async () => {
    const response = await request(baseUrl).get("/mechanics").expect(200);
    expect(response.body).to.be.an("array");
  });

  it("should fetch a mechanic by ID", async () => {
    const testId = 1; // Змініть на наявний ID
    const response = await request(baseUrl).get(`/mechanics/${testId}`).expect(200);
    expect(response.body).to.have.property("mechanicId", testId);
  });

  it("should return 404 for a non-existent mechanic", async () => {
    const invalidId = 9999; // Невірний ID
    await request(baseUrl).get(`/mechanics/${invalidId}`).expect(404);
  });
});
