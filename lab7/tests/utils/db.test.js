import { expect } from "chai";
import request from "supertest";

describe("Database Connection Tests", () => {
  const baseUrl = "http://localhost:5192/api";

  it("should connect to the database", async () => {
    const response = await request(baseUrl).get("/customers").expect(200);
    expect(response.body).to.be.an("array");
  });

  it("should handle errors gracefully", async () => {
    const invalidEndpoint = "/invalidEndpoint";
    await request(baseUrl).get(invalidEndpoint).expect(404);
  });
});
