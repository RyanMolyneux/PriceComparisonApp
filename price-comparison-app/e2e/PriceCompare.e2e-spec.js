const nsAppium = require("nativescript-dev-appium");
nsAppium.startServer();
describe("Price Compare E2E", () => {
    let driver;

    beforeAll(async () => {
        driver = await nsAppium.createDriver();

    });

    afterAll(async () => {
        await driver.quit();
        console.log("Quit driver!");
    });

    afterEach(async function () {
        await driver.logTestArtifacts("failure");
    });

    it("Ensure All elements loaded properly on the page.", async () => {
        const titleBar = await driver.findElementByAccessibilityId("TitleBar");
        const contentBody = await driver.findElementByAccessibilityId("ContentBody");
        const resultingComparison = await driver.findElementByAccessibilityId("ResultingComparison");

        expect( titleBar == null ).not.toBe(true);
        expect( contentBody == null ).not.toBe(true);
        expect( primaryProductCompared == null ).not.toBe(true);
        expect( resultingComparison == null ).not.toBe(true);
        expect( secondaryProductCompared == null ).not.toBe(true);


    });
});
