// 1. Version using Promises (.then/.catch)
const fetchWeatherWithPromises = (city) => {
    const url = `https://api.open-meteo.com/v1/forecast?latitude=17.3850&longitude=78.4867&current_weather=true`;

    fetch(url)
        .then(response => {
            if (!response.ok) throw new Error("Network response was not ok");
            return response.json();
        })
        .then(data => {
            console.log(`--- Weather Report (Promises) ---`);
            console.log(`Temperature: ${data.current_weather.temperature}°C`);
            console.log(`Wind Speed: ${data.current_weather.windspeed} km/h`);
        })
        .catch(error => console.error(`Error: ${error.message}`));
};

// 2. Version using async/await and try/catch (Technical Requirement)
const fetchWeatherAsync = async () => {
    // Technical Constraints: Use arrow functions, template literals, and try/catch
    const apiUrl = `https://api.open-meteo.com/v1/forecast?latitude=17.3850&longitude=78.4867&current_weather=true`;

    try {
        const response = await fetch(apiUrl);
        
        if (!response.ok) {
            throw new Error(`HTTP Error! Status: ${response.status}`);
        }

        const data = await response.json();
        const { temperature, windspeed, time } = data.current_weather;

        // Display formatted report using template literals
        console.log(`
--- 🌤️ WEATHER DATA REPORT (Async/Await) ---
Time: ${time}
Current Temperature: ${temperature}°C
Wind Speed: ${windspeed} km/h
------------------------------------------
        `);

    } catch (error) {
        // Handle errors properly
        console.error(`Failed to fetch weather data: ${error.message}`);
    }
};

// Execute the functions
fetchWeatherAsync();